const FormatDate = (dateIn: Date): string => {
    const date = new Date(dateIn);
    return date.getDate() + "." + (date.getMonth() + 1) + "." + date.getFullYear();
}

export default FormatDate;