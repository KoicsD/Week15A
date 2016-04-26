using System;
using System.Runtime.Serialization;

namespace Serializing
{
    [Serializable]
    class Person: IDeserializationCallback
    {
        public enum EGender: int { Male, Female }
        
        private DateTime birthDate;
        [NonSerialized] int age;

        public string Name { get; set; }
        public EGender Gender { get; set; }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
                CalculateAge();
            }
        }

        public int Age
        {
            get { return age; }
        }

        public Person()
        {

        }

        public Person(string name, DateTime birthDate, EGender gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }

        void CalculateAge()
        {
            age = (int)((DateTime.Now - BirthDate).Days / 365.25);
        }

        public override string ToString()
        {
            return string.Format("Person(Name: '{0}', Age: '{1}', Gender: '{2}')", Name, Age, Gender);
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            CalculateAge();
        }
    }
}
