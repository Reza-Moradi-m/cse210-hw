using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class MemberDirectory
    {
        private Library _library;

        public MemberDirectory(Library library)
        {
            _library = library;
        }

        public void DisplayMembers()
        {
            List<Member> members = _library.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("No members registered in the library.");
                return;
            }
            Console.WriteLine("--- Member Directory ---");
            foreach (Member member in members)
            {
                string role = (member is Staff) ? "Staff" : "Member";
                Console.WriteLine($"ID: {member.MemberID}, Name: {member.Name}, Role: {role}");
            }
        }
    }
}