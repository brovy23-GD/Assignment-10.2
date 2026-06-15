<p align="center">

&#x20; <img src="https://user-gen-media-assets.s3.amazonaws.com/gpt4o\_images/64c21535-c2a5-4f28-a006-5ae5cb895b05.png" alt="Bobby Rovy Chicago Army summer GitHub banner" />

</p>



\# Assignment 10.2 - LINQ Queries and LeetCode 744



> A C# assignment repository that demonstrates \*\*Language Integrated Query (LINQ)\*\* through four practical filtering problems, plus a \*\*Binary Search\*\* solution to \*\*LeetCode 744: Find Smallest Letter Greater Than Target\*\*.



\---



\## Overview



This repository contains my work for \*\*Assignment 10.2\*\*, organized into five questions that build on LINQ fundamentals and introduce binary search thinking.



| # | Topic | Core Concept |

|---|-------|-------------|

| Q1 | Positive Number Filter | LINQ `where` with a single condition |

| Q2 | Employee Filter | LINQ `where` with two conditions (`\&\&`) |

| Q3 | City Search by Character | LINQ + `StartsWith` / `EndsWith` |

| Q4 | Numbers Greater Than 80 | LINQ query syntax on a `List<int>` |

| Q5 | LeetCode 744 | Binary search on a sorted char array |



\---



\## Why This Assignment Matters



LINQ is one of the most important tools in the C# ecosystem. It removes the need for manual loops when filtering and transforming data, and it reads almost like plain English. These exercises help build the muscle memory for writing clean, readable queries.



Problem 5 pushes into algorithm territory by practicing binary search on a sorted structure, which is a foundational interview topic.



\---



\## Tech Stack



\- \*\*Language:\*\* C#

\- \*\*Framework:\*\* .NET Console Application

\- \*\*Libraries Used:\*\*

&#x20; - `System.Linq`

&#x20; - `System.Collections.Generic`

\- \*\*Concepts Covered:\*\*

&#x20; - LINQ query syntax

&#x20; - LINQ method syntax (lambda expressions)

&#x20; - Custom class design with properties

&#x20; - Binary search algorithm

&#x20; - Wrap-around / modulo logic

\- \*\*IDE:\*\* Visual Studio

\- \*\*Version Control:\*\* Git / GitHub



\---



\## Project Structure



```text

Assignment-10.2/

├── README.md

├── .gitignore

├── Question1\_PositiveNumbers/

│   └── Program.cs

├── Question2\_EmployeeFilter/

│   └── Program.cs

├── Question3\_CitySearch/

│   └── Program.cs

├── Question4\_GreaterThan80/

│   └── Program.cs

└── Question5\_NextGreatestLetter/

&#x20;   └── Program.cs

```



\---



\## LINQ Quick Reference



Before diving into each problem, here is the core LINQ pattern used throughout this assignment.



\### Query Syntax (reads like SQL)



```csharp

var result = from item in collection

&#x20;            where condition

&#x20;            select item;

```



\### Method Syntax (uses lambda expressions)



```csharp

var result = collection

&#x20;               .Where(item => condition)

&#x20;               .ToList();

```



Both styles produce the same result. Query syntax is easier to read at first. Method syntax is more compact and chainable.



\---



\## Question 1 - Positive Numbers Filter



\### Problem



Given the list `{ 2, -1, 3, -3, 10, -200 }`, return only the positive numbers.



\### Expected Output



```text

Input:  { 2, -1, 3, -3, 10, -200 }

Output: { 2, 3, 10 }

```



\### Solution Code



```csharp

List<int> numbers = new List<int> { 2, -1, 3, -3, 10, -200 };



var positiveNumbers = from n in numbers

&#x20;                     where n > 0

&#x20;                     select n;

```



\### Whiteboard Explanation



The LINQ query acts like a filter placed on a conveyor belt.



```text

Raw numbers:  \[ 2, -1, 3, -3, 10, -200 ]

&#x20;               ↓   ↓  ↓   ↓   ↓    ↓

FILTER (>0):  \[✅,  ❌, ✅,  ❌,  ✅,   ❌]

&#x20;               ↓       ↓        ↓

Result:       \[ 2,      3,      10 ]

```



Every number is checked against the condition `n > 0`. Numbers that pass go into the result. Numbers that fail are dropped.



\### Query Flow



```mermaid

flowchart LR

&#x20;   A\["List { 2, -1, 3, -3, 10, -200 }"] --> B\["LINQ where n > 0"]

&#x20;   B --> C\["Result { 2, 3, 10 }"]

```



\---



\## Question 2 - Employee Filter



\### Problem



Create a hard-coded list of employees. Display only employees where \*\*salary > $5,000\*\* AND \*\*age < 30\*\*.



\### Expected Output



```text

Name        Salary    Age

Alice     $7,200.00    25

Diana     $6,100.00    27

Fiona     $5,500.00    29

```



\### Employee Class



```csharp

class Employee

{

&#x20;   public string Name   { get; set; }

&#x20;   public double Salary { get; set; }

&#x20;   public int    Age    { get; set; }

}

```



\### Solution Code



```csharp

var qualifiedEmployees = employees

&#x20;                           .Where(e => e.Salary > 5000 \&\& e.Age < 30)

&#x20;                           .ToList();

```



\### Whiteboard Explanation



Two conditions must be true at the same time. Think of it as a two-door checkpoint — both doors must open for the employee to pass through.



```text

Employee:    Alice       Bob       Charlie   Diana     Edward    Fiona     George

Salary>5000:  ✅          ❌         ✅         ✅         ❌         ✅         ✅

Age<30:       ✅          ✅         ❌         ✅         ✅         ✅         ❌

BOTH pass?:   ✅          ❌         ❌         ✅         ❌         ✅         ❌

```



Bob earns too little. Charlie and George are too old. Edward fails both. Alice, Diana, and Fiona clear both gates.



\### Lambda Expression Breakdown



```csharp

.Where(e => e.Salary > 5000 \&\& e.Age < 30)

//     ↑        ↑                  ↑

//  "for each  check salary       AND check age

//  employee e"

```



`e =>` is a lambda — it is shorthand for "given an employee I'll call `e`, evaluate this condition."



\---



\## Question 3 - City Search by First and Last Character



\### Problem



From a list of cities, find any city that \*\*starts with 'A'\*\* and \*\*ends with 'M'\*\*.



\### Expected Output



```text

The city starting with 'A' and ending with 'M' is: AMSTERDAM

```



\### Solution Code



```csharp

var matches = from city in cities

&#x20;             where city.StartsWith("A") \&\& city.EndsWith("M")

&#x20;             select city;

```



\### Whiteboard Explanation



```text

City:          ROME  LONDON  NAIROBI  CALIFORNIA  ZURICH  NEW DELHI  AMSTERDAM  ABU DHABI  PARIS

Starts with A:  ❌     ❌       ❌         ✅         ❌        ❌          ✅           ✅        ❌

Ends with M:    ❌     ❌       ❌         ❌         ❌        ❌          ✅           ❌        ❌

BOTH match?:    ❌     ❌       ❌         ❌         ❌        ❌          ✅           ❌        ❌

```



CALIFORNIA starts with A but ends with A, so it fails.  

ABU DHABI starts with A but ends with I, so it fails.  

AMSTERDAM starts with A and ends with M, so it passes.



\### String Methods Used



| Method | What It Does | Example |

|--------|-------------|---------|

| `StartsWith("A")` | Returns `true` if the first character is A | `"AMSTERDAM".StartsWith("A")` → `true` |

| `EndsWith("M")` | Returns `true` if the last character is M | `"AMSTERDAM".EndsWith("M")` → `true` |



\---



\## Question 4 - Numbers Greater Than 80



\### Problem



From the list `{ 55, 200, 740, 76, 230, 482, 95 }`, display all numbers greater than 80.



\### Expected Output



```text

All members    : 55 200 740 76 230 482 95

Greater than 80: 200 740 230 482 95

```



\### Solution Code



```csharp

var greaterThan80 = from n in numbers

&#x20;                   where n > 80

&#x20;                   select n;

```



\### Whiteboard Explanation



```text

Numbers:  55   200   740   76   230   482   95

>80?:      ❌   ✅    ✅    ❌   ✅    ✅    ✅

Result:        200   740        230   482   95

```



55 and 76 are dropped. The other five pass. The original order is preserved because LINQ does not sort unless you tell it to.



\---



\## Question 5 - LeetCode 744: Find Smallest Letter Greater Than Target



\### Problem



Given a sorted character array and a target character, return the \*\*smallest character that is lexicographically greater than the target\*\*.



If no such character exists, return the \*\*first character\*\* in the array (wrap around).



\### Examples



```text

Input: letters = \["c","f","j"], target = "a"  →  Output: "c"

Input: letters = \["c","f","j"], target = "c"  →  Output: "f"

Input: letters = \["x","x","y","y"], target = "z"  →  Output: "x"

```



\### Core Insight - Think Binary Search



The array is sorted. That means we do not need to look at every element. We can use binary search to find the exact position where the target would fit, and then read the character immediately to its right.



\### Mental Model



Imagine placing the target on a sorted line of letters:



```text

Array:   \[ c ] \[ f ] \[ j ]



target = 'a'  →  a would go here: | c | f | j

&#x20;                                  ↑

&#x20;                          nearest right neighbor = 'c'



target = 'c'  →  c is here:      c | f | j

&#x20;                                   ↑

&#x20;                          nearest right neighbor = 'f'



target = 'z'  →  z would go here: c | f | j |

&#x20;                                              ↑

&#x20;                          nothing to the right → wrap to 'c'

```



\### Binary Search Walkthrough



\*\*letters = \[c, f, j], target = 'a'\*\*



```text

lo = 0, hi = 3  (hi starts at length, one past the end)



Step 1:

&#x20; mid = (0 + 3) / 2 = 1 → letters = 'f'\[2]

&#x20; 'f' > 'a'? YES → 'f' is a candidate, but maybe something smaller exists to the left

&#x20; Move hi = 1



Step 2:

&#x20; lo = 0, hi = 1

&#x20; mid = (0 + 1) / 2 = 0 → letters = 'c'

&#x20; 'c' > 'a'? YES → even better candidate

&#x20; Move hi = 0



lo == hi → loop ends

hi = 0 → letters\[0 % 3] = letters = 'c'

```



\*\*letters = \[c, f, j], target = 'z'\*\*



```text

lo = 0, hi = 3



Step 1:

&#x20; mid = 1 → letters = 'f'\[2]

&#x20; 'f' > 'z'? NO → search right half

&#x20; Move lo = 2



Step 2:

&#x20; lo = 2, hi = 3

&#x20; mid = 2 → letters = 'j'\[3]

&#x20; 'j' > 'z'? NO → search right half

&#x20; Move lo = 3



lo == hi == 3 → loop ends

hi = 3 → letters\[3 % 3] = letters = 'c' (wrap around)

```



\### Solution Code



```csharp

public char NextGreatestLetter(char\[] letters, char target)

{

&#x20;   int lo = 0;

&#x20;   int hi = letters.Length; // start hi one past the end



&#x20;   while (lo < hi)

&#x20;   {

&#x20;       int mid = (lo + hi) / 2;



&#x20;       if (letters\[mid] > target)

&#x20;           hi = mid;       // mid is a candidate; look left for something smaller

&#x20;       else

&#x20;           lo = mid + 1;   // mid is too small or equal; search right

&#x20;   }



&#x20;   return letters\[hi % letters.Length]; // modulo handles the wrap-around case

}

```



\### Decision Rules Inside the Loop



```text

letters\[mid] > target  →  move hi = mid   (mid might be the answer; keep it)

letters\[mid] <= target →  move lo = mid+1 (mid can't be the answer; skip it)

```



\### Binary Search Flow



```mermaid

flowchart TD

&#x20;   A\["lo=0, hi=3<br/>mid=1 → 'f'<br/>'f' > 'a'? YES → hi=1"] --> B\["lo=0, hi=1<br/>mid=0 → 'c'<br/>'c' > 'a'? YES → hi=0"]

&#x20;   B --> C\["lo=0, hi=0<br/>lo == hi → STOP<br/>return letters\[0 % 3] = 'c'"]

```



\### Complexity



| Metric | Value | Reason |

|--------|-------|--------|

| Time | O(log n) | Binary search halves the window each step |

| Space | O(1) | Only two integer pointers are used |



\---



\## How to Run



1\. Open any question folder in \*\*Visual Studio\*\*.

2\. Build the solution with `Ctrl + Shift + B`.

3\. Run the program with `Ctrl + F5`.

4\. Read the output in the console window.



Each `Program.cs` file is self-contained and runs independently.



\---



\## Development Flow



```mermaid

gitGraph

&#x20;  commit id: "Create Assignment 10.2 repo"

&#x20;  commit id: "Add Q1 - Positive numbers LINQ filter"

&#x20;  commit id: "Add Q2 - Employee salary and age filter"

&#x20;  commit id: "Add Q3 - City start/end character search"

&#x20;  commit id: "Add Q4 - Numbers greater than 80"

&#x20;  commit id: "Add Q5 - LeetCode 744 binary search solution"

&#x20;  commit id: "Add full README with whiteboard explanations"

```



\---



\## What I Learned



\- Writing LINQ in both query syntax and method syntax

\- Combining multiple conditions inside a `where` clause using `\&\&`

\- Using `StartsWith()` and `EndsWith()` inside LINQ filters

\- Creating custom classes with properties to model real data

\- Thinking through binary search step by step

\- Using the modulo operator to handle wrap-around edge cases

\- Explaining algorithmic logic clearly enough to whiteboard it



\---



\## Key Vocabulary



| Term | Meaning |

|------|---------|

| LINQ | Language Integrated Query — query syntax built into C# |

| `where` | Filters items that meet a condition |

| `select` | Picks what to return from the filtered items |

| Lambda (`=>`) | A short anonymous function such as `e => e.Age < 30` |

| `ToList()` | Forces LINQ to execute and returns a concrete list |

| Binary Search | A search strategy that cuts the search space in half each step |

| Lexicographic | Alphabetical ordering of characters |

| Wrap-around | Returning to the beginning when the end is exceeded |

| Modulo (`%`) | Returns the remainder and is used here to cycle back to index 0 |



\---



\## Author



\*\*Bobby Rovy\*\*  

Army veteran transitioning into tech with a focus on backend development, cloud, security, and building strong C# fundamentals.

