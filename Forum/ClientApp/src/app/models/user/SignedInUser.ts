export interface SignedInUser{
    id: number;
    profileImagePath: string;
    rating: number;
    isActive: boolean;
    registrationDate: Date;
    userName: string;    
    email: string;
    token: string;
    likedToIds: number[];
    dislikedToIds: number[];
}