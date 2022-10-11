using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            member = new List<Person>();
        }
        private List<Person> member;

        public List<Person> Member
        {
            get { return member; }
            set { member = value; }
        }

        public void AddMember(Person member)
        {
            this.member.Add(member);
        }
        public Person GetOldestMember()
        {
            return this.member
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }

    }
}
