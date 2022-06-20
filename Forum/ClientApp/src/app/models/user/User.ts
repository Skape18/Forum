import { Tag } from "../tag/Tag";

export interface User{
    id: number;
    profileImagePath: string;
    rating: number;
    isActive: boolean;
    registrationDate: Date;
    userName: string;
    description: string;
    email: string;
    tags: Tag[];
}