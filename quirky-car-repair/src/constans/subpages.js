export const SUBPAGES = [
    {
        name: "Magazyn",
        path: "/warehouse",
        permission: ['admin', 'storekeeper', 'mechanic'],
    },
    {
        name: "Serwis",
        path: "/service",
        permission: ['admin', 'user', 'mechanic'],
    },
    {
        name: "Admin",
        path: "/admin",
        permission: ['admin'],
    },
    {
        name: "O nas",
        path: "/about",
    },
    {
        name: "Kontakt",
        path: "/contact",
    },
];