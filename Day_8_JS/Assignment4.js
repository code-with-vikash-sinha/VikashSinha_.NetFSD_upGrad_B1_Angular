class Vehicle{
    constructor(brand,speed){
        this.brand = brand ,
        this.speed = speed 
    }
  
    start(){
        console.log(`Vechile is started with speed : ${this.speed}`);
    }
}
class Car extends Vehicle {
    constructor(brand,speed,fuelType){
        super(brand,speed),
        this.fuelType = fuelType ;
    }
    showDetails(){
        console.log(`Brand Name is ${this.brand}`),
        console.log(`Speed is ${this.speed}`),
        console.log(`the fueltype is ${this.fuelType}`) ;
    }
}

let C1 = new Car("Tata",60,"Petrol");
C1.showDetails();
C1.start();
