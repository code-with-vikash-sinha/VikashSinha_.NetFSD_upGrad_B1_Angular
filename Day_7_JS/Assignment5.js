let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];

// 1. Remove duplicates
let unique = [...new Set(numbers)];
console.log("Unique:", unique);

// 2. Second largest
let secondLargest = [...new Set(numbers)]
  .sort((a,b)=>b-a)[1];
console.log("Second Largest:", secondLargest);

// 3. Frequency
let frequency = numbers.reduce((acc,n)=>{
  acc[n]=(acc[n]||0)+1;
  return acc;
},{});
console.log("Frequency:", frequency);

// 4. First non-repeating
let firstNonRepeat = numbers.find(n =>
  numbers.filter(x=>x===n).length===1
);
console.log("First Non-Repeating:", firstNonRepeat);

// 5. Rotate by 2
let rotated = [...numbers.slice(2), ...numbers.slice(0,2)];
console.log("Rotated:", rotated);

// 6. Flatten nested
let flat = [1,2,[3,4,[5]]].flat(Infinity);
console.log("Flattened:", flat);

// 7. Missing number
let arr=[1,2,3,5,6];
let n=6;
let missing = (n*(n+1)/2) - arr.reduce((a,b)=>a+b,0);
console.log("Missing Number:", missing);