
const cartItems = [
    { name: "Notebook", price: 50, quantity: 2 },
    { name: "Pen", price: 10, quantity: 5 },
    { name: "Bag", price: 500, quantity: 1 }
];


const calculateTotal = (items) => {
    return items
        .map(item => item.price * item.quantity)
        .reduce((total, value) => total + value, 0);
};


const generateInvoice = (items) => {

    const itemDetails = items.map(item => {
        const subtotal = item.price * item.quantity;
        return `${item.name} - ₹${item.price} x ${item.quantity} = ₹${subtotal}`;
    }).join("\n");

    const totalAmount = calculateTotal(items);

    return `
=========== SHOPPING CART INVOICE ===========
${itemDetails}
----------------------------------------------
Total Amount: ₹${totalAmount}
==============================================
`;
};


const invoice = generateInvoice(cartItems);
console.log(invoice);