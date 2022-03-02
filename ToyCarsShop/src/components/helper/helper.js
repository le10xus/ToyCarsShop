const CarTypeEnum = {
    Sedan: 1,
    Jeep: 2,
    Bus: 3,
    Van: 4
};

const ColorEnum = {
    Black: 1,
    White: 2,
    Red: 3,
    Blue: 4,
    Gray: 5
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

export default {
    getKeyByValue,
    getCarTypeById,
    getColorById,
    CarTypeEnum,
    ColorEnum
};