export const tryParseInt = (str: string) => {
    let match = str.match(/^\d+$/);

    if (match !== null) {
        return parseInt(match[0]);
    }

    return null;
}
