using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ManipulationLogs.Controllers
{
    public class HomeController : Controller
    {
        private string URL = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

        // GET: Home
        public ActionResult Index()
        {
            List<string> logsMINHACDN = new List<string>();
            List<string> logsAgora = new List<string>();

            const string providerHttp = "MINHA CDN";
            List<string> methodStatus = new List<string>();
            List<string> codeUri = new List<string>();
            List<string> pathTime = new List<string>();
            List<string> takenResponse = new List<string>();
            List<string> sizeCache = new List<string>();
            List<string> status = new List<string>();

            StreamReader reader = new StreamReader(WebRequest.Create(URL).GetResponse().GetResponseStream());

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                logsMINHACDN.Add(line);
                string[] logs = line.Split('|');


                sizeCache.Add(logs[0]);

                codeUri.Add(logs[1]);

                status.Add(logs[2].Replace("INVALIDATE", "REFRESH_HIT"));


                string log = logs[3].Replace("\"", "");

                string[] log4Split = log.Split(' ');

                methodStatus.Add(log4Split[0]);

                pathTime.Add(log4Split[1]);


                string[] log5Split = logs[4].Split('.');

                takenResponse.Add(log5Split[0]);

            }

            for (int i = 0; i < logsMINHACDN.Count; i++)
            {
                logsAgora.Add('"' + providerHttp + '"' + " " + methodStatus[i] + " " + codeUri[i] + " " + pathTime[i] + " " + takenResponse[i] + " " + sizeCache[i] + " " + status[i]);
            }

            List<string> data = new List<string>() {
            "#Version: 1.0",
            "#Date: " + DateTime.Now.ToLocalTime(),
            "#Fields: provider http - method status - code uri - path time - taken response - size cache - status"};

            //data.Add("#Version: 1.0");
            //data.Add("#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            //data.Add("#Fields: provider http - method status - code uri - path time - taken response - size cache - status");

            ViewBag.Version = data;

            //ViewBag.Version = "#Version: 1.0";
            //ViewBag.Data = "#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //ViewBag.Fields = "#Fields: provider http - method status - code uri - path time - taken response - size cache - status";

            ViewBag.ListaLogsAgora = logsAgora;

            return View();
        }
    }
}