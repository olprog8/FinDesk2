using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Models;
using FinDesk2.ViewModels;
using FinDesk2.Data;

using System.Net;
using System.Net.Mail;
using System.Text;

using FinDesk.DAL.Context;

namespace FinDesk2.Infrastructure.Services.InMemory
{
    public class InMemoryIssuesMail : IIssuesMail
    {
        private readonly FinDeskDB _db;
        public InMemoryIssuesMail(FinDeskDB db) => _db = db;


        //smtp сервер
        static string smtpHost = "gateway.dhl.com";
        //smtp порт
        static int smtpPort = 25;
        //логин
        static string login = "ruhrpadm";
        //пароль
        static string pass = "Rh121212";

        //От кого письмо
        static string from = "ruhrpadm@dhl.com";
        //Кому письмо
        static string to = "";

        static SmtpClient client;
        static MailMessage mess = null;

        //Тема письма
        static string mesSubjBegin = "", mesSubj = "", mesBody = "";
        static string HTMLtr1 = "", HTMLtr2 = "", HTMLtr3 = "", HTMLtr4 = "", HTMLtr5 = "";


        static void makeMailClient()
        {
            //создаем подключение
            client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(login, pass);
        }

        public int SendMailById(SimpleIssueMailViewModel simpleIssueMailViewModel, long NewId)
        {


            HTMLtr4 = "<table bgcolor=\"#DEFF93\"><tr><td><p style = \"color: black\">Run application <a href=\"\\\\RUMOWWS20000410\\Data\\Work\\USERS\\FinDesk\\FinDesk.exe\">FinDesk</a> .</p></td></tr>";
            HTMLtr5 = "<tr><td><p style = \"color: black\">This is a system message, please don't answer it.</p></td></tr></table>";

            mesSubjBegin = "(FinDesk) Request No:";

            makeMailClient();

            //Создаем сообщение
            switch (simpleIssueMailViewModel.IssueStatus)
            {
                case "New":
                    {

                        //#                        to = "alexey.kuzmenko@dhl.ru";
                        //
                        to = "oleg.lesnitsky@dhl.com";

                        mesSubj = mesSubjBegin + NewId.ToString() + " with status [New] is added! ";
                        //mesBody = "Greeting, Lyana,\n\nRequest No:" + reqId + " from <" + reqManLgn + "> is added to FinDesk System with status [1]!\n\nPlease approve.\n\n\n\nApplication path~ M:\\Work\\USERS\\FinDesk\\FinDesk.exe\n\nThis is a system message, please don't answer it.";
                        HTMLtr1 = "<p style = \"color: black\">Greeting,</p><p>";
                        HTMLtr2 = "<p style = \"color: black\">Request No:<a href=\"#\">" + NewId.ToString() + "</a></b> " +"from <" + simpleIssueMailViewModel.User + "> is added to FinDesk System with " +
                            "<b>status [New]</b>" +
                            "!</p>";
                        //HTMLtr3 = "<p style = \"color: black\"><i>Please set ApproveLevel 0.</i></p>";

                        mesBody = HTMLtr1 + HTMLtr2 + HTMLtr3 + HTMLtr4 + HTMLtr5;

                        mess = new MailMessage(from, to, mesSubj, mesBody);

                        mess.IsBodyHtml = true;

                        //mess.CC.Add("albina.kutlueva@dhl.com");
                        //mess.CC.Add("oleg.lesnitsky@dhl.com");
                        //HTMLtr2 = "<p style = \"color: black\">Request No:<a asp-controller=\"SimpleIssue\" asp-action=\"Details\" asp-route-id=" + NewId.ToString() + ">" + NewId.ToString() + "</a></b> " + "from <" + simpleIssueMailViewModel.User + "> is added to FinDesk System with " +

                        break;
                    }

            }

            mess.BodyEncoding = Encoding.UTF8;

            try
            {
#if DEBUG
                    client.Send(mess);
#endif

                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();

                return 0;
            }

        }

    }
}
