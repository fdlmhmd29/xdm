﻿using System;
using System.Collections.Generic;
using XDM.Core.Downloader;
using XDM.Core.Downloader.Adaptive.Dash;
using XDM.Core.Downloader.Adaptive.Hls;
using XDM.Core.Downloader.Progressive;
using XDM.Core.Downloader.Progressive.DualHttp;
using XDM.Core.Downloader.Progressive.SingleHttp;
using XDM.Core.UI;

namespace XDM.Core
{
    public interface IApplicationCore
    {
        public Version AppVerion { get; }

        public void AddDownload(Message message);

        public string? StartDownload(
            IRequestData info,
            string fileName,
            FileNameFetchMode fileNameFetchMode,
            string? targetFolder,
            bool startImmediately,
            AuthenticationInfo? authentication,
            ProxyInfo? proxyInfo,
            int maxSpeedLimit, string? queueId,
            bool convertToMp3);

        public void StopDownloads(IEnumerable<string> list, bool closeProgressWindow = false);

        public void ResumeDownload(Dictionary<string, BaseDownloadEntry> list, bool nonInteractive = false);

        public void ResumeNonInteractiveDownloads(IEnumerable<string> idList);

        public bool IsDownloadActive(string id);

        public int ActiveDownloadCount { get; }

        public void RenameDownload(string id, string folder, string file);

        public AuthenticationInfo? PromptForCredential(string id, string message);

        public void RestartDownload(BaseDownloadEntry entry);

        public string? GetPrimaryUrl(BaseDownloadEntry entry);

        public void RemoveDownload(BaseDownloadEntry entry, bool deleteDownloadedFile);

        public void ShowProgressWindow(string downloadId);

        public void HideProgressWindow(string id);

        public void Export(string path);

        public void Import(string path);

        void UpdateSpeedLimit(string id, bool enable, int limit);

        bool GetLiveDownloadSpeedLimit(string id, out bool enabled, out int limit);

        void AddBatchLinks(List<Message> messages);
    }
}