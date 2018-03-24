/*
* Created by Narek Yegoryan 21/03/18 16:26
*/

// reference

let person = { name: 'John' };

let anotherPerson = person;

person.name = "Aclice";

console.log(person.name);
console.log(anotherPerson.name);

const obj = new Object();
console.log(obj.constructor.prototype);