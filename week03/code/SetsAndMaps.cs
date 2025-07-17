using System.Diagnostics;
using System.Text.Json;

/// <summary>
/// Class that implements problems related to sets and maps.
/// </summary>
public static class SetsAndMaps
{
    /// <summary>
    /// Returns all symmetric word pairs using a HashSet for O(n) time complexity.
    /// A symmetric pair is where the reverse of the word also exists in the list.
    /// Words like "am" and "ma" form a symmetric pair, but duplicates or identical letters like "aa" are ignored.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // Skip words with same characters (e.g. "aa")
            if (word[0] == word[1]) continue;

            string reverse = new string(new char[] { word[1], word[0] });

            if (seen.Contains(reverse))
            {
                result.Add($"{word} & {reverse}");
            }

            seen.Add(word);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Summarizes the degrees earned by parsing the 4th column of a CSV file.
    /// Populates a dictionary with degree name as key and occurrence count as value.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determines whether two words are anagrams using a dictionary of character counts.
    /// Ignores spaces and case sensitivity.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var dict1 = BuildCharFrequency(word1);
        var dict2 = BuildCharFrequency(word2);

        return dict1.Count == dict2.Count && !dict1.Except(dict2).Any();
    }

    /// <summary>
    /// Helper method to build character frequency dictionary from a string.
    /// Converts to lowercase and ignores spaces.
    /// </summary>
    private static Dictionary<char, int> BuildCharFrequency(string word)
    {
        var dict = new Dictionary<char, int>();
        foreach (char c in word.ToLower())
        {
            if (c == ' ') continue;
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict[c] = 1;
        }
        return dict;
    }

    /// <summary>
    /// Downloads daily earthquake data from USGS and extracts location and magnitude information.
    /// Requires FeatureCollection.cs with correct structure to match JSON response.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        if (featureCollection != null && featureCollection.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                var props = feature.Properties;
                if (props != null && !string.IsNullOrEmpty(props.Place) && props.Mag != null)
                {
                    summary.Add($"{props.Place} - Mag {props.Mag:F2}");
                }
            }
        }

        return summary.ToArray();
    }
}