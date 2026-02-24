let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

// 1. Passed students
let passed = students.filter(s => s.marks >= 40);
console.log("Passed:", passed);

// 2. Distinction students
let distinction = students.filter(s => s.marks >= 85);
console.log("Distinction:", distinction);

// 3. Class average
let average = students.reduce((sum, s) => sum + s.marks, 0) / students.length;
console.log("Class Average:", average);

// 4. Topper
let topper = students.reduce((top, s) =>
  s.marks > top.marks ? s : top);
console.log("Topper:", topper);

// 5. Count failed
let failedCount = students.filter(s => s.marks < 40).length;
console.log("Failed Count:", failedCount);

// 6. Convert marks to grades
let graded = students.map(s => ({
  ...s,
  grade:
    s.marks >= 85 ? "A" :
    s.marks >= 60 ? "B" :
    s.marks >= 40 ? "C" : "Fail"
}));
console.log("Grades:", graded);