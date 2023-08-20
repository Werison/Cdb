export class CdbResponse {
    grossResult: number;
    liquidResult: number;

    constructor(grossResult: number, liquidResult: number) {
        this.grossResult = grossResult;
        this.liquidResult = liquidResult;
    }
}