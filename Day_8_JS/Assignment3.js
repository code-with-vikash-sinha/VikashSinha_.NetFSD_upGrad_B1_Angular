class Student{
    constructor(name,marks){
     this.name = name ;
     this.marks = marks
    }
    addMarks(newMark){
     this.marks = [...this.marks , ...newMark] ;
     console.log(`Your total Marks is ${this.marks}`)
    }
    getAverage(){
     let count = 0 ;
     let total = 0 ;
     for(let mark of this.marks){
       total += mark ;
       count++ ;
     }
      let average = total / count ;
      console.log(`Average is ${average}`) ;
      return average;
    }
    getGrade() {
        let avg = this.getAverage();
        if(avg >=90){
            console.log('Grade A');
        }
        else if(avg >=75){
            console.log("Grade B");
        }
        else if(avg >=50){
            console.log("Grade C");
        }
        else{
            console.log("Fail");
        }
    }
}
let S1 = new Student("virat",[10,20,30,40]);
S1.addMarks([20,40]);
S1.getAverage();
S1.getGrade();