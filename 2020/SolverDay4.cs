using AoC.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AoC.Solvers
{
    public class SolverDay4 : Solver
    {
        public SolverDay4(string inputFile):base(inputFile)
        {
            Name = "Day 4";
            
        } 
        public override string SolvePart1()
        {
            var inputText = System.IO.File.ReadAllText(inputFileName);
            var regex = new Regex(@"((?<fields>(?<field_name>\w+):(?<field_value>#?\w+))( |(\r\n)?))+");
            var matches = regex.Matches(inputText);
            Console.WriteLine($"{matches.Count} matches found");
            var passports = new List<Passport>();
            foreach (Match match in matches)
            {
                passports.Add(new Passport(match.Groups["fields"].Captures.Select(c=>c.Value).ToList()));
            }
            return passports.Where(p=>p.IsValidPart1).Count().ToString();
        }
        public override string SolvePart2()
        {
            var inputText = System.IO.File.ReadAllText(inputFileName);
            var regex = new Regex(@"((?<fields>(?<field_name>\w+):(?<field_value>#?\w+))( |(\r\n)?))+");
            var matches = regex.Matches(inputText);
            Console.WriteLine($"{matches.Count} matches found");
            var passports = new List<Passport>();
            foreach (Match match in matches)
            {
                passports.Add(new Passport(match.Groups["fields"].Captures.Select(c=>c.Value).ToList()));
            }
            var validPassports = passports.Where(p=>p.IsValid).ToList();
            return validPassports.Count().ToString();
        }

        public void TestPart2(string inputFile, string expected)
        {
            var inputText = System.IO.File.ReadAllText(inputFile);
            var regex = new Regex(@"((?<fields>(?<field_name>\w+):(?<field_value>#?\w+))( |(\r\n)?))+");
            var matches = regex.Matches(inputText);
            Console.WriteLine($"{matches.Count} matches found");
            var passports = new List<Passport>();
            foreach (Match match in matches)
            {
                passports.Add(new Passport(match.Groups["fields"].Captures.Select(c=>c.Value).ToList()));
            }
            var validPassports = passports.Where(p=>p.IsValid).ToList();
            var actual = validPassports.Count().ToString();
            Console.WriteLine($"Expected {expected}, Actual {actual}");
        }

        
    }

    class Passport
    {

//          byr (Birth Year) - four digits; at least 1920 and at most 2002.
// iyr (Issue Year) - four digits; at least 2010 and at most 2020.
// eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
// hgt (Height) - a number followed by either cm or in:
// If cm, the number must be at least 150 and at most 193.
// If in, the number must be at least 59 and at most 76.
// hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
// ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
// pid (Passport ID) - a nine-digit number, including leading zeroes.
// cid (Country ID) - ignored, missing or not
        [Required, Range(1920,2002)]
        public int byr {get { return _fields.ContainsKey("byr")?int.Parse(_fields["byr"]):0;}}
        [Required, Range(2010,2020)]
        public int iyr {get { return _fields.ContainsKey("iyr")?int.Parse(_fields["iyr"]):0;}}
        [Required]
        [Range(2020,2030)]
        public int eyr {get { return _fields.ContainsKey("eyr")?int.Parse(_fields["eyr"]):0;}}
       [Required]
        public string hgt {get { return _fields.ContainsKey("hgt")?_fields["hgt"]:null;}}
        [Required, RegularExpression(@"^\#(\d|[a-f]){6}$")]
        public string hcl {get { return _fields.ContainsKey("hcl")?_fields["hcl"]:null;}}
        [Required,RegularExpression(@"^((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth))$")]
        public string ecl {get { return _fields.ContainsKey("ecl")?_fields["ecl"]:null;}}
        [Required, RegularExpression(@"^[0-9]{9}$")]
        public string pid {get { return _fields.ContainsKey("pid")?_fields["pid"]:null;}}
        public string cid {get { return _fields.ContainsKey("cid")?_fields["cid"]:null;}}

        List<ValidationResult> validationResults = new List<ValidationResult>();

        public virtual bool IsValid => isValid();

        public virtual bool IsValidPart1 { get {
            return  (byr != null) && 
                    (iyr != null) && 
                    (eyr != null) && 
                    (hgt != null) &&
                    (hcl != null) &&
                    (ecl != null) && 
                    (pid != null);

        }}
        

            

        private Dictionary<string,string> _fields = new Dictionary<string, string>();
        public Passport(IEnumerable<string> fields)
        {
            foreach (var field in fields)
            {
                var parts = field.Split(":");
                _fields.Add(parts[0],parts[1]);
            }     
        }

        bool isValid()
        {
            var ctx = new ValidationContext(this);
            validationResults = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(this,ctx,validationResults);
            valid = valid && heightIsValid();
            valid = valid && Regex.IsMatch(hcl,@"^\#(\d|[a-f]){6}$");
            valid = valid && Regex.IsMatch(ecl,@"^((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth))$");
            valid = valid && Regex.IsMatch(pid,@"^[0-9]{9}$");
            valid = valid && byr >= 1920 && byr <= 2002;
            valid = valid && eyr >= 2020 && eyr <= 2030;
            valid = valid && iyr >= 2010 && iyr <= 2020;
            return valid; 
        }


// hgt (Height) - a number followed by either cm or in:
// If cm, the number must be at least 150 and at most 193.
// If in, the number must be at least 59 and at most 76.
        bool heightIsValid()
        {
            var regex = new Regex(@"(?<height>\d+)(?<unit>\S+)");
            var match = regex.Match(hgt);
            var value = int.Parse(match.Groups["height"].Value);
            var unit = match.Groups["unit"].Value;
            if(unit == "cm")
            {
                return value >= 150 && value <= 193;
            }
            else if(unit == "in")
            {
                return value >= 59 && value <= 76;
            }
            else{
                return false;
            }
        }

    }


}