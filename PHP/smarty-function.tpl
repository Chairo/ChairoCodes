<{function menu level=0}>
<{$level}>
<{foreach $data as $entry}>
<li><{$entry}></li>
<{/foreach}>
<{/function}>
<{$menu = ['item1','item2','item3' => ['item3-1','item3-2','item3-3' =>['item3-3-1','item3-3-2']],'item4']}>
<{menu data=$menu}>