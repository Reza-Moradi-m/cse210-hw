using System;

namespace LibraryManagement
{
    public class NotificationService
    {
        public NotificationService()
        {
        }

        public void SendNotification(Loan loan, double fine)
        {
            Console.WriteLine($"[Notification] Dear {loan.Member.Name}, your loan for '{loan.Book.Title}' is overdue. " +
                              $"Current fine: ${fine:0.00}.");
        }
    }
}