let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

// 1. Display all book titles
let titles = books.map(book => book.title);
console.log("Book Titles:", titles);

// 2. Total inventory value
let totalValue = books.reduce((total, book) =>
  total + (book.price * book.stock), 0);
console.log("Total Inventory Value:", totalValue);

// 3. Books costing above ₹500
let costlyBooks = books.filter(book => book.price > 500);
console.log("Books above ₹500:", costlyBooks);

// 4. Increase price by 5%
let increasedPrice = books.map(book => ({
  ...book,
  price: book.price * 1.05
}));
console.log("After 5% Increase:", increasedPrice);

// 5. Sort by price (low → high)
let sortedBooks = [...books].sort((a, b) => a.price - b.price);
console.log("Sorted by Price:", sortedBooks);

// 6. Remove book by ID
let idToRemove = 2;
let updatedBooks = books.filter(book => book.id !== idToRemove);
console.log("After Removing ID 2:", updatedBooks);

// 7. Check if any book is out of stock
let outOfStock = books.some(book => book.stock === 0);
console.log("Any Out of Stock?", outOfStock);