class BankAccount{
    constructor(accountHolder , balance){
        this.accountHolder = accountHolder;
        this.balance = balance;
    }
    deposit(amount) {
         this.balance += amount ;
        console.log(`Your Deposit Amount is ${amount}`);
    }
    withdraw(amount){
        if(this.balance>=amount){
            this.balance -= amount;
            console.log(`withdraw Acount is ${amount}`);
        }
        else{
            console.log("Cannot withdraw");
        }
        
    }
    checkBalance(){
        console.log(`Your Available Balance is ${this.balance}`) ;
    }
}
let p1 = new BankAccount("name",30000);
p1.deposit(20000);
p1.withdraw(80000);
p1.checkBalance();