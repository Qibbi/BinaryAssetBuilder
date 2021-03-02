using BinaryAssetBuilder.Core.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BinaryAssetBuilder.Core.IO
{
    public class PathMonitor
    {
        public const int EventLimit = 20;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(PathMonitor), "Monitors paths for file changes");

        private readonly List<FileSystemWatcher> _watchers;
        private readonly List<string> _changedFiles;
        private int _numEvents;
        private bool _unrecoverableErrorOccured;

        public bool IsResultTrustable => !_unrecoverableErrorOccured && _numEvents < EventLimit;

        public PathMonitor(string[] pathsToMonitor)
        {
            _changedFiles = new List<string>();
            _watchers = new List<FileSystemWatcher>(pathsToMonitor.Length);
            _numEvents = 0;
            _unrecoverableErrorOccured = false;
            for (int idx = 0; idx < pathsToMonitor.Length; ++idx)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(pathsToMonitor[idx]);
                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.Error += OnError;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
                watcher.EnableRaisingEvents = true;
                _watchers.Add(watcher);
            }
        }

        private void OnChanged(object source, FileSystemEventArgs args)
        {
            ++_numEvents;
            _changedFiles.Add(args.FullPath);
        }

        private void OnRenamed(object source, RenamedEventArgs args)
        {
            ++_numEvents;
            _changedFiles.Add(args.OldFullPath);
        }

        private void OnError(object source, ErrorEventArgs args)
        {
            _unrecoverableErrorOccured = true;
        }

        private void Flush()
        {
            foreach (FileSystemWatcher watcher in _watchers)
            {
                FileSystemUtils.FlushVolume(watcher.Path[0]);
            }
        }

        public void Reset()
        {
            _numEvents = 0;
            _changedFiles.Clear();
        }

        public List<string> GetChangedFiles()
        {
            try
            {
                Flush();
            }
            catch (Exception ex)
            {
                _tracer.TraceWarning("BinaryAssetBuilder was unsuccessful at flushing a monitored disk volume.\n    It is likely that another application has an open handle to this volume - please close this application or move your repository to another drive. Path monitoring will be disabled.\n" + ex.Message);
                return new List<string>();
            }
            Thread.Sleep(100);
            return new List<string>(_changedFiles);
        }
    }
}
