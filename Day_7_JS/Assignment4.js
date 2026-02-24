let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

// 1. Total salary expense
let totalSalary = employees.reduce((sum,e)=> sum+e.salary,0);
console.log("Total Salary:", totalSalary);

// 2. Highest & Lowest paid
let highest = employees.reduce((a,b)=> a.salary>b.salary?a:b);
let lowest = employees.reduce((a,b)=> a.salary<b.salary?a:b);
console.log("Highest:", highest);
console.log("Lowest:", lowest);

// 3. Increase IT salary by 15%
let updatedSalary = employees.map(e =>
  e.dept==="IT" ? {...e, salary:e.salary*1.15} : e
);

// 4. Group by department
let grouped = employees.reduce((acc,e)=>{
  acc[e.dept]=acc[e.dept]||[];
  acc[e.dept].push(e);
  return acc;
},{});
console.log("Grouped:", grouped);

// 5. Department-wise average salary
let deptAvg = employees.reduce((acc,e)=>{
  acc[e.dept]=acc[e.dept]||{total:0,count:0};
  acc[e.dept].total+=e.salary;
  acc[e.dept].count++;
  return acc;
},{});

for(let d in deptAvg){
  deptAvg[d]=deptAvg[d].total/deptAvg[d].count;
}
console.log("Dept Average:", deptAvg);

// 6. Sort descending
let sortedEmployees = [...employees].sort((a,b)=> b.salary-a.salary);
console.log("Sorted Employees:", sortedEmployees);