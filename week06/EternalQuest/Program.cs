using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
{
    abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public int Points => _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();
        public string GetName() => _shortName;
    }

    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_shortName}: {_description}";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override void RecordEvent()
        {

        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName}: {_description} (eternal)";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName},{_description},{_points}";
        }
    }

    class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            _amountCompleted++;
            if (_amountCompleted >= _target)
            {
                _points += _bonus;
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName}: {_description} (Completed {_amountCompleted}/{_target} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }
    }

    class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private string _filePath;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "goals.txt");
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\nEternal Quest Program");
                Console.WriteLine("1. Display Player Info");
                Console.WriteLine("2. List Goal Names");
                Console.WriteLine("3. List Goal Details");
                Console.WriteLine("4. Create Goal");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Save Goals");
                Console.WriteLine("7. Load Goals");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayPlayerInfo();
                        break;
                    case "2":
                        ListGoalNames();
                        break;
                    case "3":
                        ListGoalDetails();
                        break;
                    case "4":
                        CreateGoal();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        SaveGoals();
                        break;
                    case "7":
                        LoadGoals();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nCurrent Score: {_score}");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("\nGoal Names:");
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetName());
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("\nGoal Details:");
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        public void CreateGoal()
        {
            Console.Write("Enter goal type (Simple/Eternal/Checklist): ");
            string type = Console.ReadLine();
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid input. Points must be a number.");
                return;
            }

            switch (type.ToLower())
            {
                case "simple":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "eternal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "checklist":
                    Console.Write("Enter target number of completions: ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid input. Target must be a number.");
                        return;
                    }
                    Console.Write("Enter bonus points: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid input. Bonus must be a number.");
                        return;
                    }
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        public void RecordEvent()
        {
            Console.WriteLine("\nSelect a goal to record:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
            {
                _goals[choice - 1].RecordEvent();
                _score += _goals[choice - 1].Points;
                Console.WriteLine("Event recorded!");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public void SaveGoals()
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(_filePath))
                {
                    outputFile.WriteLine(_score);
                    foreach (var goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string[] lines = File.ReadAllLines(_filePath);
                    _score = int.Parse(lines[0]);
                    _goals.Clear();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(':');
                        string type = parts[0];
                        string[] details = parts[1].Split(',');

                        switch (type)
                        {
                            case "SimpleGoal":
                                _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                                break;
                            case "EternalGoal":
                                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                                break;
                            case "ChecklistGoal":
                                _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
                                break;
                        }
                    }
                    Console.WriteLine("Goals loaded successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}