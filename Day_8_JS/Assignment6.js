class Shape {
    calculateArea() {
        console.log("Area calculation not implemented");
    }
}
class Circle extends Shape {
    constructor(radius){
        super();
        this.radius = radius;
    }
    calculateArea(){
        return Math.PI * this.radius * this.radius ;
    }
}
class Rectangle extends Shape {
    constructor(length,width){
        super();
        this.length = length;
        this.width = width;
    }
    calculateArea(){
        return this.length * this.width ;
    }
}
class Triangle extends Shape {
    constructor(base, height) {
        super();
        this.base = base;
        this.height = height;
    }

    calculateArea() {
        return 0.5 * this.base * this.height;
    }
}
let shapes = [
    new Circle(5),
    new Rectangle(4, 6),
    new Triangle(3, 8)
];

for (let shape of shapes) {
    console.log("Area:", shape.calculateArea());
}