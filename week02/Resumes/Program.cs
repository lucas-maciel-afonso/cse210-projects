using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._company = "Intel";
        job2._jobTitle = "Developer";
        job2._startYear = 2002;
        job2._endYear = 2010;

        Job job3 = new Job();
        job3._company = "AMD";
        job3._jobTitle = "Programmer";
        job3._startYear = 2015;
        job3._endYear = 2018;

        Job job4 = new Job();
        job4._company = "Terere";
        job4._jobTitle = "Electric Engineer";
        job4._startYear = 1999;
        job4._endYear = 2013;

        // job1.Display();
        // job2.Display();
        // job3.Display();
        // job4.Display();

        Resume resume1 = new Resume();
        resume1._name = "John Snow";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        Resume resume2 = new Resume();
        resume2._name = "Peter Parker";
        resume2._jobs.Add(job3);
        resume2._jobs.Add(job4);

        resume1.Display();
        resume2.Display();
    }
}