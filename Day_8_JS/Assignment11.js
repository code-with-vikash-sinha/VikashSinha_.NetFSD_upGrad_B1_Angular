class User {
    constructor(password) {
        this._password = "";   
        this.password = password; 
    }

    set password(value) {
        if (value.length >= 6) {
            this._password = value;
        } else {
            console.log("Password must be at least 6 characters long.");
        }
    }

    get password() {
        return this._password;
    }
}

let user1 = new User("vik123");
console.log(user1.password);  

let user2 = new User("123");
console.log(user2.password); 