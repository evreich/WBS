// утилиты для рассчета Эффективности инвестиций

import { currencyFormat } from './formatHelper';

export const getDoh = function (total, additional, period, year, netMargin, marginAddedValue, savingsPerYear) {
    const FluxFinanciers = calculateFluxFinanciers(period);
    const Annuelle = calculateAnnuelle(FluxFinanciers, total, marginAddedValue, additional, savingsPerYear);
    let sum = 0;
    for (let i = 0; i < 15; i++) {
        if (Annuelle[i] === "X")
            break;
        sum += parseFloat(Annuelle[i]);
    }
    if (sum === 0)
        return "0,00";
    //Предполагаемая ставка дисконта взята 10%
    let discVrem = 10;
    let discVrem1 = 0;
    //Осуществляем отделение корней
    let NVP = 0;
    let NVP1 = 0;
    let findLeft = false;
    for (let i = 0; i < 15; i++) {
        if (Annuelle[i] === "X")
            break;
        NVP += parseFloat(Annuelle[i]) / Math.pow((1 + discVrem / 100), parseFloat(i + 1));
    }
    if (NVP < 0)
        findLeft = true;
    if (NVP === 0 || Math.abs(0 - NVP) < 0.001)
        return currencyFormat(discVrem.toString());
    let count = 0;
    while (count <= 500000) {
        if (discVrem === -100) {
            return "0%";
        }//точка разрыва
        discVrem1 = discVrem;
        if (findLeft) {
            discVrem = discVrem - 1;
        }
        else {
            discVrem++;
        }
        NVP1 = NVP;
        NVP = 0;
        for (let i = 0; i < 15; i++) {
            if (Annuelle[i] === "X")
                break;
            NVP += parseFloat(Annuelle[i]) / Math.pow((1 + discVrem / 100), parseFloat(i + 1));
        }
        if (NVP === 0 || Math.abs(0 - NVP) < 0.001)
            return currencyFormat(discVrem.toString());
        if (NVP1 < 0 && NVP > 0 || NVP < 0 && NVP1 > 0) {
            break;
        }
        count++;
    }
    //Был найден отрезок, на котором расположен корень уравнения (или цикл вышел по ограничению кол-ва итераций)
    if (count === 50001) {
        return "ОШИБКА"; //аналог ошибки в экселе, интервал найти не удалось
    }
    count = 0;
    let discVrem2 = 0;
    let NVP2 = 0;
    while (count <= 10000) {
        discVrem2 = (discVrem + discVrem1) / 2;
        for (let i = 0; i < 15; i++) {
            if (Annuelle[i] === "X")
                break;
            NVP2 += parseFloat(Annuelle[i]) / Math.pow((1 + discVrem2 / 100), parseFloat(i + 1));
        }
        if (NVP2 < 0 && NVP > 0 || NVP < 0 && NVP2 > 0) {
            NVP1 = NVP2;
            discVrem1 = discVrem2;
        }
        else {
            NVP = NVP2;
            discVrem = discVrem2;
        }
        if (Math.abs(discVrem1 - discVrem) < 0.00001)
            return Math.round(((discVrem1 + discVrem) / 2) * 100) / 100 + "%";
        //return currencyFormat((discVrem1 + discVrem) / 2) + "%";
        count++;
    }
    return "0,00";
}


export const getNVP = function (total, additional, period, year, netMargin, marginAddedValue, savingsPerYear, Discont) {
    const FluxFinanciers = calculateFluxFinanciers(period);
    const Annuelle = calculateAnnuelle(FluxFinanciers, total, marginAddedValue, additional, savingsPerYear);
    let NVP = 0;
    for (let i = 0; i < 15; i++) {
        if (Annuelle[i] === "X")
            break;
        NVP += parseFloat(Annuelle[i]) / Math.pow((1 + Discont / 100), parseFloat(i + 1));
    }
    return currencyFormat(NVP);
}

export const getSmile = function (total, additional, period, year, netMargin, marginAddedValue, savingsPerYear, Discont) {
    const FluxFinanciers = calculateFluxFinanciers(period);
    const Annuelle = calculateAnnuelle(FluxFinanciers, total, marginAddedValue, additional, savingsPerYear);
    const Actualise = calculateActualize(Annuelle, FluxFinanciers, Discont);
    const CumulActu = calculateCumulActu(Actualise);
    const PayBack = calculatePayBack(FluxFinanciers, CumulActu);
    let sum = 0;
    for (let i = 0; i < 15; i++) {
        sum += parseFloat(PayBack[i]);
    }
    return (sum !== 0 && sum < period) ? true : false;
}

export const getPayback = function (total, additional, period, year, netMargin, marginAddedValue, savingsPerYear, Discont) {
    const FluxFinanciers = calculateFluxFinanciers(period);
    const Annuelle = calculateAnnuelle(FluxFinanciers, total, marginAddedValue, additional, savingsPerYear);
    const Actualise = calculateActualize(Annuelle, FluxFinanciers, Discont);
    const CumulActu = calculateCumulActu(Actualise);
    const PayBack = calculatePayBack(FluxFinanciers, CumulActu);
    let sum = 0;
    for (let i = 0; i < 15; i++) {
        sum += parseFloat(PayBack[i]);
    }
    return sum === 0 ? "??>" + period.toString() : sum.toString();
}

export const calculateFluxFinanciers = function (period) {
    const FluxFinanciers = new Array();
    FluxFinanciers[0] = "0";
    FluxFinanciers[1] = period.toString() === FluxFinanciers[0] ? FluxFinanciers[1] = "X" : (parseFloat(FluxFinanciers[0]) + 1).toString();
    for (let i = 2; i < 15; i++) {
        FluxFinanciers[i] = FluxFinanciers[i - 1] === "X" ? "X" : FluxFinanciers[i - 1] === period.toString() ? "X" : (parseFloat(FluxFinanciers[i - 1]) + 1).toString();
    }
    return FluxFinanciers;
}

export const calculateAnnuelle = function (FluxFinanciers, total, marginAddedValue, additional, savingsPerYear) {
    const Annuelle = new Array();
    Annuelle[0] = (-total).toString();
    for (let i = 1; i < 15; i++) {
        Annuelle[i] = FluxFinanciers[i] === "X" ? "X" : (marginAddedValue - additional + savingsPerYear).toString();
    }
    return Annuelle;
}

export const calculateActualize = function (Annuelle, FluxFinanciers, Discont) {
    const Actualise = new Array();
    Actualise[0] = (parseFloat(Annuelle[0]) / Math.pow(1 + Discont / 100, parseFloat(FluxFinanciers[0]) - 1)).toString();
    for (let i = 1; i < 15; i++) {
        Actualise[i] = Annuelle[i] === "X" ? "X" : (parseFloat(Annuelle[i]) / Math.pow(1 + Discont / 100, parseFloat(FluxFinanciers[i]) - 1)).toString();
    }
    return Actualise;
}

export const calculateCumulActu = function (Actualise) {
    const CumulActu = new Array();
    CumulActu[0] = Actualise[0];
    for (let i = 1; i < 15; i++) {
        CumulActu[i] = Actualise[i] === "X" ? "X" : (parseFloat(Actualise[i]) + parseFloat(CumulActu[i - 1])).toString();
    }
    return CumulActu;
}

export const calculatePayBack = function (FluxFinanciers, CumulActu) {
    const PayBack = new Array();
    PayBack[0] = "0";
    for (let i = 1; i < 15; i++) {
        PayBack[i] = CumulActu[i] === "X" ? "0" : parseFloat(CumulActu[i]) >= 0 && parseFloat(CumulActu[i - 1]) < 0 ? FluxFinanciers[i] : "0";
    }
    return PayBack;
}

