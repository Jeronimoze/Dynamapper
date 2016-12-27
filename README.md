# Dynamapper
<h1>Dynamic to entity mapper for .Net</h1>
<br />

<h2>Features</h2>
Dynamapper is an extension library to extend dynamic list of items to a list of specific entities.

A dynamic SQL Query using ADO .Net, Dapper or another ORM framework may return a dynamic list of items of type: <b>IEnumerable&#60;dynamic&#62;</b>
<br />
Example - Execute a query and map it to a list of dynamic objects:

<div class="highlight highlight-source-cs"><pre><span class="pl-k">public</span> <span class="pl-k">static</span> IEnumerable&lt;<span class="pl-k">dynamic</span>&gt; Query (<span class="pl-c1">this</span> IDbConnection cnn, <span class="pl-k">string</span> sql, <span class="pl-k">object</span> param = <span class="pl-c1">null</span>, SqlTransaction transaction = <span class="pl-c1">null</span>, <span class="pl-k">bool</span> buffered = <span class="pl-c1">true</span>)</pre></div>

This method will execute SQL and return a dynamic list.

<h2>Map to Entity</h2>
This helper provides an extension method to Map a list of dynamic to your entity.
<br />
Example usage:

<h4>1) Create your entity class</h4>
<div class="highlight highlight-source-cs">
<pre>
<span class="pl-k">public</span> <span class="pl-k">class</span> <span class="pl-en">Employee</span>
{
    <span class="pl-k">public</span> <span class="pl-k">int</span><span class="pl-en"> Id</span> { <span class="pl-k">get</span>; <span class="pl-k">set</span>; }
    <span class="pl-k">public</span> <span class="pl-k">string</span> <span class="pl-en">Name</span> { <span class="pl-k">get</span>; <span class="pl-k">set</span>; }
    <span class="pl-k">public</span> <span class="pl-k">DateTime</span>? <span class="pl-en">Birth</span> { <span class="pl-k">get</span>; <span class="pl-k">set</span>; }
}            
</pre>
</div>

<h4>2) Map</h4>
<div class="highlight highlight-source-cs">
<pre>

<span class="pl-en">using</span> <span class="pl-k">Dynamapper</span>;

<span class="pl-en">var</span> <span class="pl-k">employees</span> <span class="pl-k">=</span> <span class="pl-k">dynamicItems.Map&#60;Employee&#62;()</span>;
</pre>
</div>
