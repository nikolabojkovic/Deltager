import { ProductPackage } from './product-package.model';

export interface Container {
    id: number;
    name: string;
    products: ProductPackage[];
}
