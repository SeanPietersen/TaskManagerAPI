﻿namespace TaskManager.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public int Dutration { get; set; }
        public string Task1 { get; set; }
        public string Task2 { get; set; }
        public string Task3 { get; set; }
        public string Task4 { get; set; }
        public string Task5 { get; set; }
        public DateTime DueDate { get; set; }

    }
}