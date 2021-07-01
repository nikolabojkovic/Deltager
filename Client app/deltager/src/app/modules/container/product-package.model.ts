export class ProductPackage {
    id: number;
    name: string;
    type: string;
    productPackageId: number;

    constructor(id: number, name: string, type: string, productPacageId: number) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.productPackageId = productPacageId;
    }
}
