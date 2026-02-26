class Product {
    constructor({ name, price, category = "General", tags = [] }) {
        this.name = name;
        this.price = price;
        this.category = category;
        this.tags = [...tags]; 
    }

    getDetails = () => {
        
        return `Product: ${this.name}
         Price: ₹${this.price}
         Category: ${this.category}
         Tags: ${this.tags.join(", ")}`;
    }

    addTags(...newTags) {
        this.tags = [...this.tags, ...newTags];
    }
}

let product1 = new Product({
    name: "Laptop",
    price: 55000,
    category: "Electronics",
    tags: ["Tech", "Portable"]
});

product1.addTags("New Arrival", "Discount");


console.log(product1.getDetails());