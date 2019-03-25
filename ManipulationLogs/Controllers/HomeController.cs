using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ManipulationLogs.Models;

namespace ManipulationLogs.Controllers
{
    public class HomeController : Controller
    {
        private string URL = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

        // GET: Home
        public ActionResult Index()
        {
            List<string> logsMINHACDN = new List<string>();
            List<LogsAgora> listLogsAgora = new List<LogsAgora>();

			const string providerHttp = "\"MINHA CDN\"";

			StreamReader reader = new StreamReader(WebRequest.Create(URL).GetResponse().GetResponseStream());

            while (!reader.EndOfStream)
            {
				LogsAgora logAgora = new LogsAgora();

                string line = reader.ReadLine();
                logsMINHACDN.Add(line);
                string[] logs = line.Split('|');

				logAgora.ProviderHttp = providerHttp;

				logAgora.SizeCache = logs[0];

				logAgora.CodeUri = logs[1];

				logAgora.Status = logs[2].Replace("INVALIDATE", "REFRESH_HIT");

				string log = logs[3].Replace("\"", "");

                string[] log4Split = log.Split(' ');

				logAgora.MethodStatus = log4Split[0];

				logAgora.PathTime = log4Split[1];

                string[] log5Split = logs[4].Split('.');

				logAgora.TakenResponse = log5Split[0];

				listLogsAgora.Add(logAgora);

            }

			ViewBag.Version = "#Version: 1.0";
			ViewBag.Data = "#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
			ViewBag.Fields = "#Fields: provider http - method status - code uri - path time - taken response - size cache - status";

			return View(listLogsAgora);
        }
    }
}