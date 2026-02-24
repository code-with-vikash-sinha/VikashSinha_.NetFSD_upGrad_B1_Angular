let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];

// 1. Total cart value
let totalCartValue = cart.reduce((total, item) =>
  total + (item.price * item.qty), 0);
console.log("Total Cart Value:", totalCartValue);

// 2. Increase quantity of product ID 2
cart = cart.map(item =>
  item.id === 2 ? { ...item, qty: item.qty + 1 } : item
);

// 3. Remove product ID 3
cart = cart.filter(item => item.id !== 3);

// 4. Apply 10% discount above ₹10,000
cart = cart.map(item =>
  item.price > 10000 ? { ...item, price: item.price * 0.9 } : item
);

// 5. Sort by total item price
let sortedCart = [...cart].sort((a, b) =>
  (b.price * b.qty) - (a.price * a.qty)
);
console.log("Sorted Cart:", sortedCart);

// 6. Any product > ₹50,000?
let expensive = cart.some(item => item.price > 50000);
console.log("Any above 50k?", expensive);

// 7. All items in stock?
let allInStock = cart.every(item => item.qty > 0);
console.log("All in stock?", allInStock);