using System;

namespace k8sdemo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}