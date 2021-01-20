using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk2.Models;
using FinDesk.Domain.Entities;
using FinDesk2.ViewModels;


namespace FinDesk2.Infrastructure.Interfaces
{
    public interface IIssuesMail
    {
        int SendMailById(SimpleIssueMailViewModel MailModel, long NewId);
    }
}
