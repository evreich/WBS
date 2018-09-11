
// Перевод в денежный формат вида XXX XXX XXX,XX
export const currencyFormat = (value) => {
    if (value !== null && value !== 0) {
        if (navigator.userAgent.search(/MSIE/) > 0) {
            if (typeof (value) === "string") {
                return parseFloat(value).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1 ").replace('.', ',');
            }
            else {
                return value.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1 ").replace('.', ',');
            }
        }
        else {
            const FeildsFormat = new Intl.NumberFormat("ru-RU",
                {
                    style: 'currency', currency: 'RUB',
                    minimumFractionDigits: 2, maximumFractionDigits: 2
                });
            if (value.toString().indexOf(".") === -1 && value.toString().indexOf(",") !== -1)
                return (FeildsFormat.format(value.toString().replace(",", "."))).replace("₽", "").trim();
            else
                return FeildsFormat.format(value).replace("₽", "").trim();
        }
    } else {
        return "0,00";
    }
}

export const convertToDouble = (p) => {
    let isValidTemp = 0;
    if (typeof p === 'undefined' || p === null) return isValidTemp;
    p = p.match(/\s/g) !== null ? p.replaceAll(/\s/g, "") : p;
    if (p !== "") {
        p = p.indexOf("%") !== -1 ? p.replaceAll("%", "") : p;
        p = p.indexOf("$") !== -1 ? p.replaceAll("$", "") : p;
        p = p.indexOf("(") !== -1 ? p.replaceAll("(", "") : p;
        p = p.indexOf(")") !== -1 ? p.replaceAll(")", "") : p;
        p = p.indexOf(">") !== -1 ? p.replaceAll(">", "") : p;
        p = p.indexOf("<") !== -1 ? p.replaceAll("<", "") : p;
        p = p.indexOf("?") !== -1 ? p.replaceAll("?", "") : p;
        p = p.indexOf(",") !== -1 ? p.replaceAll(",", ".") : p;
        if (p !== "") {
            isValidTemp = parseFloat(p);
        }
    }
    return isValidTemp;
}