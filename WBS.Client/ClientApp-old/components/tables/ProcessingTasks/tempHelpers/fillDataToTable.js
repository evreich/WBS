const partNumber = "0001-18-";
const date = "07.03.2018 11:52:13";
const siteName = "Mytishi";
const processingTime = "-";
const delegated = "",
    protocol = "",
    extracted = "";

export default function fillDataToTable(countElems) {
    const data = [];
    for (let i = 1; i <= countElems; i++) {
        let number, currentStage;
        const condition = i % 3;
        switch (condition) {
            case 0:
                number = partNumber + "023";
                currentStage = "Обработка технической службой (IT)";
                break;
            case 1:
                number = partNumber + "024";
                currentStage = "Обработка технической службой (IT)";
                break;
            case 2:
                number = partNumber + "026";
                currentStage = "Согласование КУ сита";
                break;
        }
        data.push({
            id: i,
            number,
            siteName,
            date,
            processingTime,
            currentStage,
            protocol,
            extracted,
            delegated
        });
    }
    return data;
}
