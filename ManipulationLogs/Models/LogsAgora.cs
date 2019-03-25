using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManipulationLogs.Models
{
	public class LogsAgora
	{
		public string ProviderHttp { get; set; }
		public string MethodStatus { get; set; }
		public string CodeUri { get; set; }
		public string PathTime { get; set; }
		public string TakenResponse { get; set; }
		public string SizeCache { get; set; }
		public string Status { get; set; }
	}
}