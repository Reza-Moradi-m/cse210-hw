using System;

namespace LibraryManagement
{
    public class Loan
    {
        private Book _book;
        private Member _member;
        private DateTime _loanDate;
        private DateTime _dueDate;
        private bool _extended; // Indicates whether the due date has been extended

        public Loan(Book book, Member member, DateTime loanDate, DateTime dueDate)
        {
            _book = book;
            _member = member;
            _loanDate = loanDate;
            _dueDate = dueDate;
            _extended = false;
        }

        public Book Book => _book;
        public Member Member => _member;
        public DateTime LoanDate => _loanDate;
        public DateTime DueDate => _dueDate;
        public bool Extended => _extended;

        public bool IsOverdue()
        {
            return DateTime.Now > _dueDate;
        }

        // Extends the due date by 7 days, if not already extended.
        public bool ExtendDueDate()
        {
            if (_extended)
                return false;
            _dueDate = _dueDate.AddDays(7);
            _extended = true;
            return true;
        }
    }
}