using System;

namespace LibraryManagement
{
    public class FineCalculator
    {
        private const double _finePerDay = 0.50; // Example: $0.50/day

        public FineCalculator()
        {
        }

        public double CalculateFine(Loan loan)
        {
            if (!loan.IsOverdue())
                return 0.0;

            // Calculate how many days overdue
            TimeSpan overdueSpan = DateTime.Now - loan.DueDate;
            int overdueDays = overdueSpan.Days;
            if (overdueDays < 1) overdueDays = 1; // at least 1 day

            return overdueDays * _finePerDay;
        }
    }
}