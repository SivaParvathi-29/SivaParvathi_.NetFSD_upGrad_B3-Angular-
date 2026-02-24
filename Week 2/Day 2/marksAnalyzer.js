
const studentMarks = [88, 82, 72, 68, 54, 40];

const normalizedMarks = studentMarks.map(mark => Number(mark));

const calculateTotal = (marksArray) => {
    return marksArray.reduce((total, mark) => total + mark, 0);
};

const calculateAverage = (marksArray) => {
    const total = calculateTotal(marksArray);
    return total / marksArray.length;
};

const getResult = (average) => {
    return average >= 50 ? "Pass ✅" : "Fail ❌";
};

const analyzeMarks = () => {

    const total = calculateTotal(normalizedMarks);
    const average = calculateAverage(normalizedMarks);
    const result = getResult(average);

    console.log(`
    ===== Student Marks Report =====
    Marks   : ${normalizedMarks.join(", ")}
    Total   : ${total}
    Average : ${average.toFixed(2)}
    Result  : ${result}
    =================================
    `);
};
analyzeMarks();
export {
    calculateTotal,
    calculateAverage,
    getResult
};