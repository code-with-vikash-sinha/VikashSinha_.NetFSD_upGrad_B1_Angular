class Wallet {
    #balance;   

    constructor(initialBalance = 0) {
        this.#balance = initialBalance;
    }

    addMoney(amount) {
        if (amount > 0) {
            this.#balance += amount;
        } else {
            console.log("Amount must be positive.");
        }
    }

    spendMoney(amount) {
        if (amount > 0 && amount <= this.#balance) {
            this.#balance -= amount;
        } else {
            console.log("Invalid amount or insufficient balance.");
        }
    }

    getBalance() {
        return this.#balance;
    }
}

let myWallet = new Wallet(1000);

myWallet.addMoney(500);
myWallet.spendMoney(300);

console.log(myWallet.getBalance()); 

// This will cause error
// console.log(myWallet.#balance);