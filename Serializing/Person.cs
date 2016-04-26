using System;

namespace Serializing
{
    [Serializable]
    class Person
    {
        public enum EGender: int { Male, Female }

        private string name;
        private DateTime birthDate;
        private EGender gender;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public EGender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Person()
        {

        }

        public Person(string name, DateTime birthDate, EGender gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
        }

        public override string ToString()
        {
            return string.Format("Person(Name: '{0}', BirthDate: '{1}', Gender: '{2}')", name, birthDate, gender);
        }
    }
}
