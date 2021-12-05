
export function beforeStart(options) {
    console.log("before start");
}

export async function afterStarted(blazor) {
    console.log("after started");

    let element = document.getElementById('alertContainer');

    await blazor.rootComponents.add(element, 'globalAlert',
        { Title: "Hello!", Message: "This was rendered via JavaScript" }); 
}