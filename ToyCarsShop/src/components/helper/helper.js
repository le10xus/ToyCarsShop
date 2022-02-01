const CarTypeEnum = {
    Sedan: 0,
    Jeep: 1,
    Bus: 2,
    Van: 3
};

const ColorEnum = {
    Black: 0,
    White: 1,
    Red: 2,
    Blue: 3,
    Gray: 4
};

function getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
}

function getCarTypeById(typeId) {
    return getKeyByValue(CarTypeEnum, typeId);
};

function getColorById(colorId) {
    return getKeyByValue(ColorEnum, colorId);
}

export default { getKeyByValue, getCarTypeById, getColorById };