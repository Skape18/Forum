export interface SignedInUser{
    profileImagePath: string,
    rating: number,
    isActive: boolean,
    registrationDate: Date,
    userName: string,    
    email: string,
    token: string
}