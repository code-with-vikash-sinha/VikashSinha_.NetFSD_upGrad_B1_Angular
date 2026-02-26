class Employee{
 constructor(name , salary){
  this.name = name ,
  this.salary = salary
 }
 getDetails(){
 console.log(`Name is ${this.name} and Salary is ${this.salary}`)
 }
}
class Manager extends Employee {
 constructor(name,salary ,bonus){
 super(name,salary);
 this.bonus = bonus
 }
 getTotalSalary(){
 this.salary = this.salary + this.bonus ;
 console.log(`Salary is ${this.salary}`)
 }
}
class Director extends Manager {
constructor(name,salary,bonus,stockOptions){
super(name,salary,bonus),
this.stockOptions = stockOptions 
}
getFullCompensation(){
 console.log(this.salary + this.bonus + this.stockOptions);
}
}

const emp = new Employee("Harsh", 30000);
emp.getDetails();

const mgr = new Manager("Rahul", 50000, 10000);
mgr.getDetails();
mgr.getTotalSalary();

const dir = new Director("Amit", 80000, 20000, 50000);
dir.getDetails();
dir.getFullCompensation();