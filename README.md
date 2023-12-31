This is a playground repo which is being used to demonstrate how to integrate HTMX with Blazor SSR components for a server-side, yet interactive, application.

Each feature demonstrates a usage of HTMX.

Counter demonstrates how to use an SSR page to render a static component on first load. Then clicking the button will trigger an API call which updates the counter and returns new HTML to be swapped in to replace the static markup. In addition, the API response contains a HX-Trigger header which triggers the same counter component in the page top bar to update as well.

Weather demonstrates how to do an HTMX load trigger which calls for markup when the page loads. I think for SSR, it makes more sense to do it like the Counter, but this was just a demo.

PageLinks demonstrates how a popup menu can work.

Cocktails is a multi-level HTMX pattern which searches a remote API for cocktails. HTMX loads the search results and clicking a result loads the detail via HTMX.  
