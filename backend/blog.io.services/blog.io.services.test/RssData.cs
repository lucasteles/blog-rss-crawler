namespace blog.io.services.test
{
    public class RssData
    {
        public readonly static string Default =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<rss version=""2.0""
    xmlns:content=""http://purl.org/rss/1.0/modules/content/""
    xmlns:wfw=""http://wellformedweb.org/CommentAPI/""
    xmlns:dc=""http://purl.org/dc/elements/1.1/""
    xmlns:atom=""http://www.w3.org/2005/Atom""
    xmlns:sy=""http://purl.org/rss/1.0/modules/syndication/""
    xmlns:slash=""http://purl.org/rss/1.0/modules/slash/"">
<channel>
    <title>TEST</title>
    <atom:link href=""http://TEST.com/feed/"" rel=""self"" type=""application/rss+xml"" />
    <link>http://TEST.com</link>
    <description>TESTESTESTESTES</description>
    <lastBuildDate>Mon, 12 Mar 2018 17:46:26 +0000</lastBuildDate>
    <language>en-US</language>
    <sy:updatePeriod>hourly</sy:updatePeriod>
    <sy:updateFrequency>1</sy:updateFrequency>
    <generator>https://wordpress.org/?v=4.9.4</generator>
    <item>
        <title>Teste de post</title>
        <link>http://TEST.com/test</link>
        <comments>http://TEST.com</comments>
        <pubDate>Fri, 09 Mar 2018 14:00:26 +0000</pubDate>
        <dc:creator><![CDATA[Test]]></dc:creator>
        <category><![CDATA[c1]]></category>
        <category><![CDATA[c2]]></category>
        <category><![CDATA[c3]]></category>
        <guid isPermaLink=""false"">http://TEST.com/?p=42</guid>
        <description><![CDATA[<p>teste</p>
]]></description>
    <content:encoded><![CDATA[<p>teste!</p>]]> </content:encoded>
    <wfw:commentRss>http://TEST.com/feed/</wfw:commentRss>
        <slash:comments>0</slash:comments>
        </item>
    </channel>
</rss>";

        public readonly static string Empty =
@"<?xml version=""1.0"" encoding=""UTF-8""?><rss version=""2.0""
    xmlns:content=""http://purl.org/rss/1.0/modules/content/""
    xmlns:wfw=""http://wellformedweb.org/CommentAPI/""
    xmlns:dc=""http://purl.org/dc/elements/1.1/""
    xmlns:atom=""http://www.w3.org/2005/Atom""
    xmlns:sy=""http://purl.org/rss/1.0/modules/syndication/""
    xmlns:slash=""http://purl.org/rss/1.0/modules/slash/"" >
<channel>
    <title>TEST</title>
    <atom:link href=""http://TEST.com/feed/"" rel=""self"" type=""application/rss+xml"" />
    <link>http://TEST.com</link>
    <description>TESTESTESTESTES</description>
    <lastBuildDate>Mon, 12 Mar 2018 17:46:26 +0000</lastBuildDate>
    <language>en-US</language>
    <sy:updatePeriod>hourly</sy:updatePeriod>
    <sy:updateFrequency>1</sy:updateFrequency>
    <generator>https://wordpress.org/?v=4.9.4</generator>
    </channel>
</rss>";


        public readonly static string OneYerLaterPost =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<rss version=""2.0""
    xmlns:content=""http://purl.org/rss/1.0/modules/content/""
    xmlns:wfw=""http://wellformedweb.org/CommentAPI/""
    xmlns:dc=""http://purl.org/dc/elements/1.1/""
    xmlns:atom=""http://www.w3.org/2005/Atom""
    xmlns:sy=""http://purl.org/rss/1.0/modules/syndication/""
    xmlns:slash=""http://purl.org/rss/1.0/modules/slash/"">
<channel>
    <title>TEST</title>
    <atom:link href=""http://TEST.com/feed/"" rel=""self"" type=""application/rss+xml"" />
    <link>http://TEST.com</link>
    <description>TESTESTESTESTES</description>
    <lastBuildDate>Mon, 12 Mar 2019 17:46:26 +0000</lastBuildDate>
    <language>en-US</language>
    <sy:updatePeriod>hourly</sy:updatePeriod>
    <sy:updateFrequency>1</sy:updateFrequency>
    <generator>https://wordpress.org/?v=4.9.4</generator>
    <item>
        <title>Teste de post</title>
        <link>http://TEST.com/test</link>
        <comments>http://TEST.com</comments>
        <pubDate>Fri, 09 Mar 2019 14:00:26 +0000</pubDate>
        <dc:creator><![CDATA[Test]]></dc:creator>
        <category><![CDATA[c1]]></category>
        <category><![CDATA[c2]]></category>
        <category><![CDATA[c3]]></category>
        <guid isPermaLink=""false"">http://TEST.com/?p=42</guid>
        <description><![CDATA[<p>teste</p>
]]></description>
    <content:encoded><![CDATA[<p>teste!</p>]]> </content:encoded>
    <wfw:commentRss>http://TEST.com/feed/</wfw:commentRss>
        <slash:comments>0</slash:comments>
        </item>
    </channel>
</rss>";

    }
}
